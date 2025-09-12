using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosAPI.Authorization
{
    public class MinimalAge : IAuthorizationRequirement
    {
        public MinimalAge(int age) 
        {
            this.Age = age;
        }
        public int Age { get; set; }
    }
}
