import React from 'react';
import NavBar from '@/components/nav/Navbar';

import { User } from '@/api/generated';
import { authApi } from '@/api';

import useFetch from '@/hooks/useFetch';

type Props = {
  children?: React.ReactNode;
  isProtected?: boolean;
};

const Layout: React.FC<Props> = ({ children, isProtected = false }) => {
  const [user, error, isLoading] = useFetch<User>(authApi.getProfile);

  const renderChild = () => {
    if (isLoading) return <div>Loading...</div>
    if (isProtected && error) {
      return <div>Unauthorized</div>
    }
    return children;
  }

  return (
    <div>
      <NavBar />
      {renderChild()}
    </div>
  );
}


export default Layout;