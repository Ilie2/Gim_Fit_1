import React from 'react';
import './Courses.css';

function Courses() {
  return (
    <div className="courses-page">
      <header className="courses-header">
        <h1>Our Courses</h1>
        <p>Explore our range of fitness courses designed to help you achieve your fitness goals.</p>
      </header>

      <section className="courses-list">
        <div className="course">
          <h2>Yoga Basics</h2>
          <p className="course-description">Learn the fundamentals of yoga, including poses and breathing techniques.</p>
          <p className="course-duration">Duration: 8 weeks</p>
          <button className="course-button">Enroll Now</button>
        </div>
        <div className="course">
          <h2>Strength Training 101</h2>
          <p className="course-description">Build strength and muscle with our beginner-friendly strength training course.</p>
          <p className="course-duration">Duration: 12 weeks</p>
          <button className="course-button">Enroll Now</button>
        </div>
        <div className="course">
          <h2>Cardio Kickboxing</h2>
          <p className="course-description">Improve cardiovascular fitness and coordination with our kickboxing classes.</p>
          <p className="course-duration">Duration: 10 weeks</p>
          <button className="course-button">Enroll Now</button>
        </div>
      </section>
    </div>
  );
}

export default Courses;
