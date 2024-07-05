import React, { useState } from 'react';
import axios from 'axios';
import './Register.css';
import { Link, useNavigate } from 'react-router-dom';

const Register = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [username, setUsername] = useState('');
  const [role, setRole] = useState('client'); // Default role is 'client'
  const [phoneNumber, setPhoneNumber] = useState('');
  const [lastName, setLastName] = useState('');
  const [age, setAge] = useState(0);
  const [experience, setExperience] = useState(0);
  const [photo, setPhoto] = useState('');
  const [description, setDescription] = useState('');
  const [subscription, setSubscription] = useState('');
  const navigate = useNavigate();

  const handleRegister = (e) => {
    e.preventDefault();
    
    if (password !== confirmPassword) {
      alert('Passwords do not match!');
      return;
    }

    let registerRequest = {
      email: email,
      password: password,
      phoneNumber: phoneNumber,
      name: username,
      lastName: lastName,
      description: description
    };

    if (role === 'client') {
      registerRequest = { ...registerRequest, subscription: subscription };
    } else {
      registerRequest = {
        ...registerRequest,
        role: 'trainer', // Set role to trainer
        age: age,
        experience: experience,
        photo: photo
      };
    }

    const endpoint = role === 'client' ? 'client/register' : 'trainer/register';

    axios.post(`https://localhost:7114/api/Auth/${endpoint}`, registerRequest)
      .then(response => {
        console.log('Registration successful:', response.data);
        localStorage.setItem('token', response.data.Token);
        navigate('/dashboard');
      })
      .catch(error => {
        console.error('There was an error registering!', error);
      });
  };

  return (
    <div className="wrapper">
      <form onSubmit={handleRegister}>
        <h1>Register as {role.charAt(0).toUpperCase() + role.slice(1)}</h1>

        <div className="input-box">
          <input
            type="text"
            placeholder="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            required
          />
        </div>

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

        <div className="input-box">
          <input
            type="password"
            placeholder="Confirm Password"
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
            required
          />
        </div>

        <div className="input-box">
          <input
            type="text"
            placeholder="Phone Number"
            value={phoneNumber}
            onChange={(e) => setPhoneNumber(e.target.value)}
            required
          />
        </div>

        <div className="input-box">
          <input
            type="text"
            placeholder="Last Name"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
            required
          />
        </div>

        {role === 'client' && (
          <div className="input-box">
            <input
              type="text"
              placeholder="Subscription"
              value={subscription}
              onChange={(e) => setSubscription(e.target.value)}
              required
            />
          </div>
        )}

        {role === 'trainer' && (
          <>
            <div className="input-box">
              <input
                type="number"
                placeholder="Age"
                value={age}
                onChange={(e) => setAge(parseInt(e.target.value))}
                required
              />
            </div>

            <div className="input-box">
              <input
                type="number"
                placeholder="Experience (years)"
                value={experience}
                onChange={(e) => setExperience(parseInt(e.target.value))}
                required
              />
            </div>

            <div className="input-box">
              <input
                type="text"
                placeholder="Photo URL"
                value={photo}
                onChange={(e) => setPhoto(e.target.value)}
                required
              />
            </div>
          </>
        )}

        <div className="input-box">
          <textarea
            placeholder="Description"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
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

        <button type="submit">Register</button>

        <div className="login-link">
          <Link to="/LoginForm">Already have an account?</Link>
        </div>
      </form>
    </div>
  );
}

export default Register;
