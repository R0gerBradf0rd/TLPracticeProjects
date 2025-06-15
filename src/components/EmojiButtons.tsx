type Props = {
  selected: string;
  onSelect: (emoji: string) => void;
};

const EmojiButtons = ({ selected, onSelect }: Props) => {
  const emojis = ['😡', '😠', '😟', '😐', '🙂', '😃'];

  return (
    <div className="emoji-row">
      {emojis.map((e) => (
        <button
          key={e}
          type="button"
          onClick={() => onSelect(e)}
          className={`emoji-button ${selected === e ? 'selected' : ''}`}
        >
          {e}
        </button>
      ))}
    </div>
  );
};

export default EmojiButtons;
