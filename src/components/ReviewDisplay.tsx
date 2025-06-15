type Props = {
  name: string;
  comment: string;
  rating: number;
};

const ReviewDisplay = ({ name, comment, rating }: Props) => {
  return (
    <div className="review-box">
      <div style={{ display: 'flex', justifyContent: 'space-between' }}>
        <p><strong>{name}</strong></p>
        <p style={{ fontSize: '13px', color: '#888' }}>{rating}/5</p>
      </div>
      <p style={{ fontSize: '14px', marginTop: '8px', whiteSpace: 'pre-line' }}>
        {comment}
      </p>
    </div>
  );
};

export default ReviewDisplay;
