import React from 'react';

import './button.css';

type ButtonProps = {
  children?: React.ReactNode;
  onClick?: Function;
  color?: string;
}

const PrimaryButton: React.FC<ButtonProps> = ({ children, onClick = () => { }, color = 'black' }) => {
  return (
    <button onClick={() => onClick()}>{children}</button>
  )
}

export default PrimaryButton;