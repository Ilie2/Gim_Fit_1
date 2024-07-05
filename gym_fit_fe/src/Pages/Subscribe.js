import React from 'react';
import './Subscribe.css';

function Subscribe() {
  return (
    <div className="subscription-offers-page">
      <header className="subscription-header">
        <h1>Subscription Offers</h1>
        <p>Choose the plan that suits your fitness goals and lifestyle.</p>
      </header>

      <section className="subscription-plans">
        <div className="subscription-plan">
          <h2>Basic Plan</h2>
          <p className="plan-price">$29.99/month</p>
          <ul className="plan-features">
            <li>Access to basic gym facilities</li>
            <li>Group fitness classes</li>
            <li>Personalized workout plans</li>
          </ul>
          <button className="plan-button">Choose Plan</button>
        </div>
        <div className="subscription-plan">
          <h2>Premium Plan</h2>
          <p className="plan-price">$49.99/month</p>
          <ul className="plan-features">
            <li>Access to all gym facilities</li>
            <li>Unlimited group fitness and yoga classes</li>
            <li>Free personal training session</li>
          </ul>
          <button className="plan-button">Choose Plan</button>
        </div>
        <div className="subscription-plan">
          <h2>Elite Plan</h2>
          <p className="plan-price">$79.99/month</p>
          <ul className="plan-features">
            <li>24/7 gym access</li>
            <li>Access to all classes and programs</li>
            <li>Personal nutrition consultation</li>
            <li>Exclusive gym merchandise</li>
          </ul>
          <button className="plan-button">Choose Plan</button>
        </div>
      </section>
    </div>
  );
}

export default Subscribe;
