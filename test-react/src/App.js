import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import './App.css';
import Home from './Home';
import { Register } from './Components/Register/Register';
import { Login } from './Components/Login/Login';
import NewPost from './Components/Posts/NewPost';
import { useState } from 'react';

function App() {
  const [isLoggedIn] = useState(() => localStorage.getItem('jwt') !== null
  );

  return (
    <Router>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/register" element={<Register />} />
          <Route path="/login" element={<Login />} />
          <Route path="/new-post" element={
            isLoggedIn ? <NewPost /> : <Navigate to="/login"/>
          }></Route>
        </Routes>
      </Router>
  );
}

export default App;
