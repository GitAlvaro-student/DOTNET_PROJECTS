using MusicSoundAPIStandard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSoundAPIStandard.Interfaces
{
    public interface ISongRepository
    {
        List<Song> GetAll();
        Song? GetById(int id);
        void Create(Song song);
        void Update(Song song);
        void Delete(int id);
    }
}
