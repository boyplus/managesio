import React from 'react';

type SubmitButtonProps = {
  isDisabled: boolean;
  text: string;
}

const SubmitButton: React.FC<SubmitButtonProps> = ({ isDisabled, text }) => {
  return (
    <button type="submit" disabled={isDisabled}>
      {text}
    </button>
  );
}

export default SubmitButton;