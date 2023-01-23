import React from 'react';
import Layout from '@/components/layout/Layout';

import '@/styles/Homes.css';

const Home: React.FC = () => {
  return (
    <Layout>
      <div className="container">
        <h1 style={{ fontSize: '4rem' }}>Managesio</h1>
        <h3>Manage your software development project with ease.</h3>
        <h3>Inspired by Jira software but much more simpler.</h3>
      </div>

    </Layout>
  );
}

export default Home;