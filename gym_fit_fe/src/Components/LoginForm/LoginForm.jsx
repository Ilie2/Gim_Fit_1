import React, { useState } from 'react';
import axios from 'axios';
import './LoginForm.css';
import { Link, useNavigate } from 'react-router-dom';

const LoginForm = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [role, setRole] = useState('client'); // Default role is 'client'
  const navigate = useNavigate();

  const handleLogin = (e) => {
    e.preventDefault();
    
    const loginRequest = {
      email: email,
      password: password
    };

    const endpoint = role === 'client' ? 'client/login' : 'trainer/login';

    axios.post(`https://localhost:7114/api/Auth/${endpoint}`, loginRequest)
      .then(response => {
        console.log('Login successful:', response.data);
        // Save the token to localStorage or context if needed
        localStorage.setItem('token', response.data.Token);
        
        // Redirect based on role
        if (role === 'client') {
          navigate('/trainers');
        } else if (role === 'trainer') {
          navigate('/TrainersAdmin');
        }
      })
      .catch(error => {
        console.error('There was an error logging in!', error);
      });
  };

  return (
    <div className="wraper">
      <form onSubmit={handleLogin}>
        <h1>Login</h1>

        <div className="input-box">
          <input
            type="email"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>

        <div className="input-box">
          <input
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>

        <div className="role-selector">
          <label>
            <input
              type="radio"
              value="client"
              checked={role === 'client'}
              onChange={(e) => setRole(e.target.value)}
            />
            Client
          </label>
          <label>
            <input
              type="radio"
              value="trainer"
              checked={role === 'trainer'}
              onChange={(e) => setRole(e.target.value)}
            />
            Trainer
          </label>
        </div>

        <div className="remember-forgot">
          <label><input type="checkbox" /> Remember me</label>
          <Link to="/">Forgot password?</Link>
        </div>

        <button type="submit">Login</button>

        <div className="register-link">
          <p>Don't have an account? <Link to="/Register">Register</Link></p>
        </div>
      </form>
    </div>
  );
};

export default LoginForm;
