import React, { Component } from 'react';
// import ReactDOM from 'react-dom';
import 'react-responsive-carousel/lib/styles/carousel.min.css';
import { Carousel } from 'react-responsive-carousel';

class ImageSlider extends Component {
  constructor(props) {
    super(props);
    this.props = props;
  }

  render() {
    return (

      <Carousel autoPlay>
        <div>
          <img src="http://lorempixel.com/output/cats-q-c-640-480-1.jpg" alt="" />
          <p className="legend">Legend 1</p>
        </div>
        <div>
          <img src="http://lorempixel.com/output/cats-q-c-640-480-1.jpg" alt="" />
          <p className="legend">Legend 2</p>
        </div>
        <div>
          <img src="http://lorempixel.com/output/cats-q-c-640-480-1.jpg" alt="" />
          <p className="legend">Legend 3</p>
        </div>
      </Carousel>

    );
  }
}

export default ImageSlider;
