import React from 'react';
import { Link } from 'react-router-dom';
import { ButtonProps } from './Button';

import './button.css';

type LinkButtonProps = ButtonProps & {
  link: string;
}
const LinkButton: React.FC<LinkButtonProps> = (props) => {
  return (
    <button>
      <Link to={props.link}></Link>
    </button>
  )
}

export default LinkButton;