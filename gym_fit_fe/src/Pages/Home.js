import "./Home.css";
import React from 'react';

function Home() {
  return (
    <div className="homepage">
      <header className="hero-section">
        <div className="hero-text">
          <h1>Welcome to GymFit</h1>
          <p>Your journey to a healthier life starts here.</p>
        </div>
        <div className="hero-image">
          <img src="https://via.placeholder.com/800x400" alt="Hero" />
        </div>
      </header>
      
      <section className="features">
        <h2>Our Features</h2>
        <div className="features-container">
          <div className="feature">
            <img src="https://via.placeholder.com/300" alt="Feature 1" />
            <h3>State-of-the-Art Equipment</h3>
            <p>We offer the latest and best equipment to help you achieve your fitness goals.</p>
          </div>
          <div className="feature">
            <img src="https://via.placeholder.com/300" alt="Feature 2" />
            <h3>Expert Trainers</h3>
            <p>Our certified trainers are here to guide you through every step of your fitness journey.</p>
          </div>
          <div className="feature">
            <img src="https://via.placeholder.com/300" alt="Feature 3" />
            <h3>Flexible Memberships</h3>
            <p>We offer a variety of membership plans to fit your lifestyle and budget.</p>
          </div>
        </div>
      </section>
      
      <section className="testimonials">
        <h2>What Our Members Say</h2>
        <div className="testimonials-container">
          <div className="testimonial">
            <img src="https://via.placeholder.com/100" alt="Member 1" />
            <p>"Fitness Gym has changed my life. The facilities are excellent and the staff is always helpful."</p>
            <h4>- Alex</h4>
          </div>
          <div className="testimonial">
            <img src="https://via.placeholder.com/100" alt="Member 2" />
            <p>"I love the variety of classes offered. There's something for everyone."</p>
            <h4>- Jamie</h4>
          </div>
          <div className="testimonial">
            <img src="https://via.placeholder.com/100" alt="Member 3" />
            <p>"The personal training sessions have been a game-changer for me. Highly recommend!"</p>
            <h4>- Sam</h4>
          </div>
        </div>
      </section>
      
      <footer className="footer">
        <p>&copy; 2024 GymFit. All rights reserved.</p>
      </footer>
    </div>
  );
}

export default Home;
