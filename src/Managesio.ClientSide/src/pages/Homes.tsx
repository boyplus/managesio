import React, { useEffect, useState } from 'react';
import { todoApi } from '../api'
import { Todo } from '../api/generated';

const Home: React.FC = () => {
  const [todos, setTodos] = useState<Todo[]>([]);

  const fetchTodos = async () => {
    const res = await todoApi.getTodos();
    setTodos(res.data);
  }

  useEffect(() => {
    fetchTodos();
  }, [])

  return (
    <div>
      <h1>Project Management App</h1>
      {todos.map(todo => {
        return <div>
          <h3>{todo.title}</h3>
        </div>
      })}
    </div>
  );
}

export default Home;