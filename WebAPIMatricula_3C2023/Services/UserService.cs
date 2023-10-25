using Microsoft.EntityFrameworkCore;
using WebAPIMatricula_3C2023.Entities;
using WebAPIMatricula_3C2023.Helpers;

namespace WebAPIMatricula_3C2023.Services;

public interface IUserService
{
    Task<Usuario> Authenticate(string username, string password);
    Task<IEnumerable<Usuario>> GetAll();
    Task<Usuario> GetById(int id);
    Task Create(Usuario user, string password);
    Task Update(Usuario user, string password = null);
    Task Delete(int id);
}

public class UserService : IUserService
{
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Usuario> Authenticate(string username, string password)
    {
        // Check username and password are valid
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return null;
        }

        // Check if username exists
        var user = await _context.Usuario.SingleOrDefaultAsync(x => x.Username == username);

        // If user exists check if password is correct
        if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            return null;
        }

        // Authentication successful
        return user;
    }

    public async Task Create(Usuario user, string password)
    {
        // Password validation
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new AppException("La contraseña es requerida.");
        }
        // Username validation
        if (_context.Usuario.Any(x => x.Username == user.Username))
        {
            throw new AppException($"Nombre de usuario '{user.Username}' ya existe.");
        }
        // Create password hash with inline variables
        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        // Add hash and salt to return object
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        // Perform and save changes
        await _context.Usuario.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var user = await _context.Set<Usuario>().SingleOrDefaultAsync(e => e.Codigo == id);
        if (user != null)
        {
            _context.Entry(user).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Usuario>> GetAll() => await _context.Set<Usuario>().ToListAsync();

    public async Task<Usuario> GetById(int id)
    {
        var user = await _context.Set<Usuario>().SingleOrDefaultAsync(e => e.Codigo == id);
        return user;
    }

    public async Task Update(Usuario userParam, string password = null)
    {
        var user = await _context.Usuario.SingleOrDefaultAsync(e => e.Codigo == userParam.Codigo);

        if (user == null)
        {
            throw new AppException("Usuario no encontrado");
        }

        // Update username if changed
        if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
        {
            // Throw an error if the new username is already taken
            if (await _context.Usuario.AnyAsync(x => x.Username == userParam.Username))
            {
                throw new AppException($"Nombre de usuario {userParam.Username} ya existe");
            }
            user.Username = userParam.Username;
        }

        if (!string.IsNullOrWhiteSpace(userParam.CorreoElectronico))
        {
            user.CorreoElectronico = userParam.CorreoElectronico;
        }

        // Update password if provided
        if (!string.IsNullOrWhiteSpace(password))
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
        }

        _context.Usuario.Update(user);
        await _context.SaveChangesAsync();
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        if (password == null)
        {
            throw new ArgumentNullException(nameof(password));
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("El password no puede ser una cadena vacía o espacios en blanco.", nameof(password));
        }
        // use hmacsha512 to generate secure hash and salt
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key; //  returns a randomly generated cryptographic key
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); // converts password string to byte array
        }
    }

    private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        if (password == null)
        {
            throw new ArgumentNullException(nameof(password));
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("El password no puede ser una cadena vacía o espacios en blanco.", nameof(password));
        }

        if (storedHash.Length != 64)
        {
            throw new ArgumentException("Longitud invalida del password hash (64 bytes esperados).", nameof(storedHash));
        }

        if (storedSalt.Length != 128)
        {
            throw new ArgumentException("Longitud invalida del password salt (128 bytes esperados).", nameof(storedSalt));
        }

        // Create hmac instance for stored salt
        using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
        {
            // computes the hash of input password using the original stored salt  
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                // ensure computed hash will match the orignal
                if (computedHash[i] != storedHash[i]) return false;
            }
        }

        return true;
    }
}
