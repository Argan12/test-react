import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';
import Home from './Home';
import { Register } from './Components/Register/Register';
import { Login } from './Components/Login/Login';
import { AuthProvider, RequireAuth } from 'react-auth-kit';
import NewPost from './Components/Posts/NewPost';

function App() {
  return (
    <AuthProvider authType = {'localstorage'}
      authName={'id'}>
      <Router>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/register" element={<Register />} />
          <Route path="/login" element={<Login />} />
          <Route path="/new-post" element={
            <RequireAuth loginPath={'/login'}><NewPost /></RequireAuth>
          }></Route>
        </Routes>
      </Router>
    </AuthProvider>
  );
}

export default App;
