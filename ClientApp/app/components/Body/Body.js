/*
    Mynd og meira á upphafsíðu
*/

import React from 'react';
import FTfeed from 'components/FTfeed';
import './style.scss';
import ImageSlider from '../ImageSlider/ImageSlider';
/*
import {
    Button, UncontrolledAlert, Card, CardImg, CardBody,
    CardTitle, CardSubtitle, CardText, Container, Row, Col
} from 'reactstrap';
*/

const Body = () => (
  <div className="container">
    <div className="row">
      <div className="col-sm">
        <ImageSlider></ImageSlider>
      </div>
      <div className="col-sm feed">
        <FTfeed></FTfeed>
      </div>
    </div>
  </div>
);

export default Body;
