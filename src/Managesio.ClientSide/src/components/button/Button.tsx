import React from 'react';

import './button.css';

export type ButtonProps = {
  children?: React.ReactNode;
  onClick?: Function;
  color?: string;
}

const Button: React.FC<ButtonProps> = ({ children, onClick = () => { }, color = 'black' }) => {
  return (
    <button onClick={() => onClick()}>{children}</button>
  )
}

export default Button;