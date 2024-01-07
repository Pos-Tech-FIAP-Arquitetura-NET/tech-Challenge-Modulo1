using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Play_investe.Entity;
using Play_investe.Interface;
using Play_investe.Services;
using System.Linq;
using UserTemplate.Services;

namespace Play_investe.Repository
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        private readonly PasswordHasherService _passwordHasher;

        public EFUserRepository(ApplicationDbContext context, PasswordHasherService passwordHasher) : base(context)
        {
            _passwordHasher = passwordHasher;
        }


        /// <summary>
        /// Faz a verificação das credenciais passadas e retorna o usuário.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User ValidatedCredential(string email, string password)
        {
            var user = _context.User.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                bool isValidCredentials = _passwordHasher.VerifyPassword(user.Password, password);
                if (isValidCredentials)
                {
                    return user;
                }
            }

            return null;
        }


        /// <summary>
        /// Faz a verificação se o email já esta registrado
        /// </summary>
        /// <param name="email"></param>        
        /// <returns></returns>
        public bool IsEmailAlreadyRegistered(string email)
        {
            var user = _context.User.FirstOrDefault(user => user.Email == email);
                         
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
                        
        }

        /// <summary>
        /// Faz a verificação se o email já esta registrado
        /// </summary>
        /// <param name="email"></param>        
        /// <returns></returns>
        public User GetUserByEmail(string email)
        {
            var user = _context.User.FirstOrDefault(user => user.Email == email);

            return user;  
        }

       



    }
}
