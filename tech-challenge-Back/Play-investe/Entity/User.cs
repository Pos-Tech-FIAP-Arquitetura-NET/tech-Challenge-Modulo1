using Microsoft.AspNetCore.Identity;
using Play_investe.Entity;
using Play_investe.DTO;
using Play_investe.Enums;
using UserTemplate.Services;

namespace Play_investe.Entity
{
    /// <summary>
    /// Representa um usuário no sistema, contendo informações essenciais e métodos relacionados. Herda propriedade Id de Entitys
    /// </summary>
    public class User : Entitys
    {       
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime DateOfBirth { get; set; }      
        public string RG { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }    
        public PermitionsTypes Permitions { get; set; }
        public bool IsActived { get; set; }
        public Account Account { get; set; }          
        public Address Address { get; set; }


        public User() { }

        /// <summary>
        /// Cria uma nova instância da classe User com as informações fornecidas, pelo SaveUserDTO
        /// </summary>
        /// <param name="userName">O nome do usuário.</param>
        /// <param name="email">O endereço de e-mail do usuário.</param>
        /// <param name="password">A senha do usuário.</param>
        /// <param Permitions="permitions">Tipo de permissão do usuário no sistema.</param>
        public User(SaveUserDTO saveUserDTO, PasswordHasherService passwordHasher)
        {
            Name = saveUserDTO.Name;
            Email = saveUserDTO.Email;
            PhoneNumber = saveUserDTO.PhoneNumber;
            CPF = saveUserDTO.CPF;
            DateOfBirth = saveUserDTO.DateOfBirth;
            RG = saveUserDTO.RG;
            DateOfIssue = saveUserDTO.DateOfIssue;
            Password = passwordHasher.HashPassword(saveUserDTO.Password);
            Permitions = saveUserDTO.Permitions;
            IsActived = true;
            CreatedDate = DateTime.Now;
            
            
        }

        public void DesactiveUser(int id)
        {
            IsActived = false;
            DesactivedDate = DateTime.Now;
        }

        public void ChangeUserPassword(string NewPassword, PasswordHasherService passwordHasher)
        {
            Password = passwordHasher.HashPassword(NewPassword);
            UpdatedDate = DateTime.Now;
        }


    }
}
