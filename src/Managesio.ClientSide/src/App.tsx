import React from 'react';
import { Routes, Route } from 'react-router-dom'
import Layout from './components/layout/Layout';
import Home from './pages/Homes';
import Profile from './pages/Profile';

const App: React.FC = () => {
  return (
    <div>
      <Routes>
        <Route path='/' element={<Layout />}>
          <Route index element={<Home />}></Route>
          <Route path="profile" element={<Profile />}></Route>
        </Route>
      </Routes>
    </div>
  );
}

export default App;