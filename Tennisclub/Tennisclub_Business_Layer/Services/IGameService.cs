using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_Business_Layer.Services
{
    public interface IGameService
    {
        IEnumerable<GameReadDto> GetAllGamesFiltered(DateTime? date);
        GameReadDto GetGameById(int id);
        GameReadDto AddGame(GameCreateDto game);
        void UpdateGame(int id, GameUpdateDto game);
        void DeleteGame(int id);

        /*IEnumerable<Game> GetAllGamesFiltered(DateTime? date);
        Game GetGameById(int id);
        void AddGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(Game game);*/

        //TODO:
        //- Alleen inplannen voor leden die actief zijn
        //- CHRONOLOGISCHE LIJST VAN WEDSTRIJDEN PER SPELER, EN KAN HIEROP FILTEREN OP DATUM
    }
}
