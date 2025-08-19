using MusicSoundAPIStandard.Interfaces;
using MusicSoundAPIStandard.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSoundAPIStandard.Repository
{
    public class SongRepository : ISongRepository
    {
        private readonly string _connectionString;

        public SongRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Song> GetAll()
        {
            var songs = new List<Song>();

            using var conn = new OracleConnection(_connectionString);
            conn.Open();

            string sql = "SELECT * FROM MUSICA.TBD_SONGS";

            using var cmd = new OracleCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                songs.Add(new Song
                {
                    Id = Convert.ToInt32(reader["ID_MUSIC"]),
                    Artista = reader["ARTISTA"].ToString(),
                    MusicaNome = reader["MUSICA"].ToString(),
                    Genero = reader["GENERO"]?.ToString(),
                    Popularidade = Convert.ToInt32(reader["POPULARIDADE"]),
                    Duracao = Convert.ToInt32(reader["DURACAO"]),
                    Ano = Convert.ToInt32(reader["ANO"])
                });
            }

            return songs;
        }

        public Song? GetById(int id)
        {
            using var conn = new OracleConnection(_connectionString);
            conn.Open();

            string sql = "SELECT * FROM MUSICA.TBD_SONGS WHERE ID_MUSIC = :id";

            using var cmd = new OracleCommand(sql, conn);
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id;

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Song
                {
                    Id = Convert.ToInt32(reader["ID_MUSIC"]),
                    Artista = reader["ARTISTA"].ToString(),
                    MusicaNome = reader["MUSICA"].ToString(),
                    Genero = reader["GENERO"]?.ToString(),
                    Popularidade = Convert.ToInt32(reader["POPULARIDADE"]),
                    Duracao = Convert.ToInt32(reader["DURACAO"]),
                    Ano = Convert.ToInt32(reader["ANO"])
                };
            }

            return null;
        }

        public void Create(Song song)
        {
            using var conn = new OracleConnection(_connectionString);
            conn.Open();

            string sql = @"INSERT INTO MUSICA.TBD_SONGS (ARTISTA, MUSICA, GENERO, POPULARIDADE, DURACAO, ANO) 
                       VALUES (:artista, :musica, :genero, :popularidade, :duracao, :ano)";

            using var cmd = new OracleCommand(sql, conn);
            cmd.Parameters.Add("artista", OracleDbType.Varchar2).Value = song.Artista;
            cmd.Parameters.Add("musica", OracleDbType.Varchar2).Value = song.MusicaNome;
            cmd.Parameters.Add("genero", OracleDbType.Varchar2).Value = song.Genero;
            cmd.Parameters.Add("popularidade", OracleDbType.Int32).Value = song.Popularidade;
            cmd.Parameters.Add("duracao", OracleDbType.Int32).Value = song.Duracao;
            cmd.Parameters.Add("ano", OracleDbType.Int32).Value = song.Ano;

            cmd.ExecuteNonQuery();
        }

        public void Update(Song song)
        {
            using var conn = new OracleConnection(_connectionString);
            conn.Open();

            string sql = @"UPDATE MUSICA.TBD_SONGS SET 
                       ARTISTA = :artista,
                       MUSICA = :musica,
                       GENERO = :genero,
                       POPULARIDADE = :popularidade,
                       DURACAO = :duracao,
                       ANO = :ano
                       WHERE ID_MUSIC = :id";

            using var cmd = new OracleCommand(sql, conn);
            cmd.Parameters.Add("artista", OracleDbType.Varchar2).Value = song.Artista;
            cmd.Parameters.Add("musica", OracleDbType.Varchar2).Value = song.MusicaNome;
            cmd.Parameters.Add("genero", OracleDbType.Varchar2).Value = song.Genero;
            cmd.Parameters.Add("popularidade", OracleDbType.Int32).Value = song.Popularidade;
            cmd.Parameters.Add("duracao", OracleDbType.Int32).Value = song.Duracao;
            cmd.Parameters.Add("ano", OracleDbType.Int32).Value = song.Ano;
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = song.Id;

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new OracleConnection(_connectionString);
            conn.Open();

            string sql = "DELETE FROM MUSICA.TBD_SONGS WHERE ID_MUSIC = :id";

            using var cmd = new OracleCommand(sql, conn);
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();
        }
    }
}
