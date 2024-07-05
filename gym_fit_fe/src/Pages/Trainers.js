import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './Trainers.css';

function TrainersAdmin() {
  const [trainers, setTrainers] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:7114/api/Trainers')
      .then(response => {
        setTrainers(response.data);
      })
      .catch(error => {
        console.error('There was an error fetching the trainers!', error);
      });
  }, []);

  return (
    <div className="trainers-page">
      <header className="trainers-header">
        <h1>Meet Our Trainers</h1>
        <p>Our professional trainers are here to help you achieve your fitness goals.</p>
      </header>

      <section className="trainers-list">
        {trainers.map(trainer => (
          <div className="trainer" key={trainer.id}>
            <img src={trainer.photo} alt={trainer.name} />
            <h3>{trainer.name} {trainer.lastName}</h3>
            <p>Specialty: {trainer.role}</p>
            <p>Bio: {trainer.description}</p>
          </div>
        ))}
      </section>
    </div>
  );
}

export default TrainersAdmin;