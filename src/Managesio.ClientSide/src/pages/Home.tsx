import React from 'react';
import Layout from '@/components/layout/Layout';

import '@/styles/home.css';
import { Link } from 'react-router-dom';

const Home: React.FC = () => {
  return (
    <Layout>
      <div className="container">
        <h1 style={{ fontSize: '4rem' }}>Managesio</h1>
        <h3>Manage your software development project with ease.</h3>
        <h3>Inspired by Jira software but much more simpler.</h3>
        <button className='try-it-free'>
          <Link to='/signup'>
            Try it free
          </Link>
        </button>
      </div>
    </Layout>
  );
}

export default Home;