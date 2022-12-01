import React from 'react';
import { Outlet } from 'react-router-dom';
import NavBar from '../nav/Navbar';

const Layout: React.FC = () => {
  return (
    <div>
      <NavBar />
      <Outlet />
    </div>
  );
}

export default Layout;