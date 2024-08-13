using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        private int id;
        private string userName;
        private string passWord;
        private string emCode;
        private string email;

        public UserDTO(int id, string userName, string passWord, string emCode, string email)
        {
            Id = id;
            UserName = userName;
            PassWord = passWord;
            EmCode = emCode;
            Email = email;
        }

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string EmCode { get => emCode; set => emCode = value; }
        public string Email { get => email; set => email = value; }
    }
}
