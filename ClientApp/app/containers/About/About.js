/*
 * FeaturePage
 *
 * List all the features
 */
import React, { Component } from 'react';
import { Helmet } from 'react-helmet';
import './style.scss';

export default class AboutPage extends Component {
  // eslint-disable-line react/prefer-stateless-function

  // Since state and props are static,
  // there's no need to re-render this component
  shouldComponentUpdate() {
    return false;
  }

  render() {
    return (
      <div className="about-page">
        <Helmet>
          <title>About Page</title>
          <meta
            name="description"
            content="Feature page of React.js Boilerplate application"
          />
        </Helmet>
        <h1>Features</h1>
        
      </div>
    );
  }
}
