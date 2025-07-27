using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicas_Oracle.Repositories
{
    public interface ITbdSongsRepository
    {
        Task InserirMusicasFromJsonAsync(string jsonContent);
    }
}
