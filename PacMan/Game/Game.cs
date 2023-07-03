
namespace PacMan {
    class Game {
        private int _delay;
        private int _lastTicks;
        private PacMan _player;
        private Level _currentLevel;
        private CharacterComposit _characterComposit;
        
        private MyLogger _logger;
        private FrameRendering _frameRendering;

        //-------------------- Singleton pattern implemented -----------------------
        private static Game _instance = new();

        private Game() {
            _logger = new MyLogger(typeof(Game));
            _frameRendering = new FrameRendering();
        }

        public static Game GetInstance() {
            return _instance;
        }

        //---------------------------------------------------------------------------

        public void Start(Level level) {
            LoadLevel(level);

            _frameRendering.RenderMap(_currentLevel);
            _logger.Info("Map rendered successfull");

            Update();
        }

        private void LoadLevel(Level level) {
            _currentLevel = level;
            _characterComposit = new CharacterComposit();

            _player = new PacMan(
                PositionOnMap.GetPositionOnMap(level.LevelMap, GameSymbols.PACMAN_SYMBOL),
                GameSymbols.PACMAN_SYMBOL
                );

            //-------------------------- Composit pattern implemented -------------------------
            _characterComposit.Add(_player);
            _characterComposit.AddRange(CreateGhosts());
            //---------------------------------------------------------------------------------

            _delay = (int)level.Difficulty;
            _lastTicks = Environment.TickCount & Int32.MaxValue;

            _characterComposit.GetCharacters().ForEach(c => _logger.Debug($"{c}"));
            _logger.Debug($"Delay: {_delay}");
        }

        private void Update() {
            _logger.Info("Update method invoked");

            while (_currentLevel.LevelPointsMap.AreSymbolsOnTheMap(
                new List<char> { GameSymbols.POINT_SYMBOL, GameSymbols.BIG_POINT_SYMBOL })) {

                if (_lastTicks + _delay <= (Environment.TickCount & Int32.MaxValue)) {
                    _lastTicks = Environment.TickCount & Int32.MaxValue;

                    //------------------------ Composit -----------------------------
                    _characterComposit.Move(_currentLevel.LevelMap);

                    //----------------------------------------------------------------

                    _player.Eat(_currentLevel.LevelPointsMap);

                    _frameRendering.RenderCharacters(_characterComposit.GetCharacters().ToArray(),
                                                    _currentLevel.LevelPointsMap,
                                                    _currentLevel.LevelMap);

                   
                    _frameRendering.RenderScore(_player.Score.AmountOfPoints);

                    if(_player.Die(_characterComposit.GetCharacters())) {
                        _frameRendering.RenderGameOver("Game over. You died :(");
                        _logger.Info("Game over. PacMan died");
                        return;
                    }
                }
            }
            _frameRendering.RenderGameOver("Congrats. You won! :)");
            _logger.Info("Game over. PacMan won");
        }

        private List<ICharacter> CreateGhosts() {
            IEnumerable<PositionOnMap> manyPositionsOnMap =
                PositionOnMap.GetManyPositionsOnMap(_currentLevel.LevelMap, GameSymbols.GHOST_SYMBOL);

            //-------------------------- Prototype pattern implemented -------------------

            Ghost ghost = new Ghost(manyPositionsOnMap.ElementAt(0), GameSymbols.GHOST_SYMBOL);
            List<ICharacter> ghosts = new List<ICharacter>() { ghost };

            ghosts.AddRange(manyPositionsOnMap
                                    .Skip(1)
                                    .Select(position => {
                                        Ghost newGhost = ghost.Copy();
                                        newGhost.PositionOnMap.XPos = position.XPos;
                                        newGhost.PositionOnMap.YPos = position.YPos;
                                        return newGhost;
                                }).ToList());

            //----------------------------------------------------------------------------

            return ghosts;
        }
    }
}
