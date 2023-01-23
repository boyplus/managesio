import React from 'react';
import { Routes, Route } from 'react-router-dom'
import Home from './pages/Homes';
import Profile from './pages/Profile';

const App: React.FC = () => {
  return (
    <div>
      <Routes>
        <Route index element={<Home />}></Route>
        <Route path="profile" element={<Profile />}></Route>
        <Route path="signin" element={<Profile />}></Route>
        <Route path="signup" element={<Profile />}></Route>
      </Routes>
    </div>
  );
}

export default App;