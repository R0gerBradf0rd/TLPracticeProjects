type Props = {
  name: string;
  comment: string;
  onNameChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  onCommentChange: (e: React.ChangeEvent<HTMLTextAreaElement>) => void;
};

const InputFields = ({ name, comment, onNameChange, onCommentChange }: Props) => {
  return (
    <div className="inputFields">
      <input
        type="text"
        className="input"
        placeholder="Как вас зовут?"
        value={name}
        onChange={onNameChange}
      />
      <textarea
        className="input textarea"
        placeholder="Напишите, что понравилось, что было непонятно"
        value={comment}
        onChange={onCommentChange}
      />
    </div>
  );
};

export default InputFields;
