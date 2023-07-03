
namespace PacMan {
    class CharacterComposit {
        private List<ICharacter> _characters;

        public CharacterComposit() {
            _characters = new List<ICharacter>();
        }

        public CharacterComposit(List<ICharacter> characters) {
            _characters = characters;
        }

        public void Add(ICharacter character) {
            _characters.Add(character);
        }

        public void Remove(ICharacter character) {
            _characters.Remove(character);
        }

        public void AddRange(List<ICharacter> characters) {
            _characters.AddRange(characters);
        }

        public List<ICharacter> GetCharacters() {
            return _characters;
        }

        public void Move(IMap map) {
            _characters.ForEach(c => c.Move(map));
        }
    }
}
