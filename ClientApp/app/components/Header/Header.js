import React from 'react';
import { Link } from 'react-router-dom';
import Banner from './images/banner.jpg';
import './style.scss';

class Header extends React.Component { // eslint-disable-line react/prefer-stateless-function
  render() {
    return (
      <div className="container padding">


        <div className="pads row">

          <div className="col">
            <img className="img" src={Banner} alt=""></img>
          </div>
          <div className="col text-center">
            <Link to="/login">
              Login
            </Link>
            /
            <Link to="/register">
              Register
            </Link>
          </div>
        </div>
        <div className="pads row">
          <div className="col">
            <Link className="btn btn-primary btn-md" to="/">
              Home
            </Link>
          </div>
          <div className="col">
            <Link className="btn btn-primary btn-md" to="/sponsors">
              Sponsors
            </Link>
          </div>
          <div className="col">
            <Link className="btn btn-primary btn-md" to="/features">
              Features
            </Link>
          </div>
          <div className="col">
            <Link className="btn btn-primary btn-md" to="/about">
              About
            </Link>
          </div>
        </div>
      </div>
    );
  }
}

export default Header;
