import React from 'react';
import Navbar from './Components/navbar/navbar';
import LoginForm from './Components/LoginForm/LoginForm'
import Register from './Components/LoginForm/Register';
import {Route,Routes} from "react-router-dom"
import Courses from "./Pages/Courses.js"
import Home from "./Pages/Home.js"
import Subscribe from "./Pages/Subscribe.js"
import Trainers from "./Pages/Trainers.js"
import TrainersAdmin from "./Pages/TrainersAdmin.js"

function App() {
  return (
    <div>
      <Navbar />
      <div className='container'>
        <Routes>
          <Route path='/' element={<Home />} />
          <Route path='/Trainers' element={<Trainers />} />
          <Route path='/Courses' element={<Courses/>} />
          <Route path='/Subscribe' element={<Subscribe />}/>
          <Route path='/LoginForm' element={<LoginForm />} />
          <Route path="/Register" element={<Register />} />
          <Route path='/TrainersAdmin' element={<TrainersAdmin/>}/>
        </Routes>
      </div>
    </div>
  );

}

export default App;
