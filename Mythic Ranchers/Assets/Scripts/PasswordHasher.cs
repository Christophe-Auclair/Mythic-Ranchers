using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class PasswordHasher: MonoBehaviour
{
    public static PasswordHasher Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        string passwordHash = HashPassword(password);
        return passwordHash == storedHash;
    }
}