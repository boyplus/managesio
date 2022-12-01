import React, { useEffect } from 'react';
import { todoApi } from '../api'

const Home: React.FC = () => {
  useEffect(() => {
    todoApi.getTodos().then(res => {
      const todos = res.data;
      console.log(todos);
    })
  }, [])
  return (
    <div>
      <h1>Home</h1>
    </div>
  );
}

export default Home;