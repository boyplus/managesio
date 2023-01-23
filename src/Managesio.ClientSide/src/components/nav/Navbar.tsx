import React from 'react';
import { Link } from 'react-router-dom';
import PrimaryButton from '@/components/button/PrimaryButton';

import './navbar.css';


const NavBar: React.FC = () => {
  return (
    <nav>
      <div>
        <h3>Managesio</h3>
      </div>
      <div className='links'>
        <Link to="/signin">Signin</Link>
        <Link to="/signup">Create account</Link>
      </div>
    </nav>
  );
}

export default NavBar;