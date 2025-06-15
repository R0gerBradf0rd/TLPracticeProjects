import { useState } from 'react';
import TextSection from './TextSection';
import EmojiButtons from './EmojiButtons';
import InputFields from './InputFields';
import ReviewDisplay from './ReviewDisplay';
import './styles.css';


function App() {
  const [name, setName] = useState('');
  const [comment, setComment] = useState('');
  const [emoji, setEmoji] = useState('');

  const [review, setReview] = useState<{
    name: string;
    comment: string;
    rating: number;
  } | null>(null);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!name || !emoji) return;

    const emojis = ['😡', '😠', '😟', '😐', '🙂', '😃'];
    const rating = emojis.indexOf(emoji);

    setReview({
      name,
      comment,
      rating,
    });

    setName('');
    setComment('');
    setEmoji('');
  };

  return (
    <div className="reviewer">
      <form onSubmit={handleSubmit} className="form-container">
        <TextSection />
        <EmojiButtons selected={emoji} onSelect={setEmoji} />
        <InputFields
          name={name}
          comment={comment}
          onNameChange={(e) => setName(e.target.value)}
          onCommentChange={(e) => setComment(e.target.value)}
        />
        <button
          type="submit"
          disabled={!name || !emoji}
          className="submit-button"
        >
          Отправить
        </button>
      </form>

      {review && (
        <ReviewDisplay
          name={review.name}
          comment={review.comment}
          rating={review.rating}
        />
      )}
    </div>
  );
}

export default App