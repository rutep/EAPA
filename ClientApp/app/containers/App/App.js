/**
 *
 * App
 *
 * This component is the skeleton around the actual pages, and should only
 * contain code that should be seen on all pages. (e.g. navigation bar)
 */

import React from 'react';
import { Helmet } from 'react-helmet';
import { Switch, Route } from 'react-router-dom';

import HomePage from 'containers/HomePage/Loadable';
import FeaturePage from 'containers/FeaturePage/Loadable';
import About from 'containers/About/Loadable';
import NotFoundPage from 'containers/NotFoundPage/Loadable';
import Sponsors from 'containers/Sponsors/Loadable';
import Header from 'components/Header';
import Footer from 'components/Footer';
import Login from 'components/Login';
import Register from 'components/Register';
import './style.scss';

const App = () => (
  <div className="app-wrapper">
    <Helmet
      titleTemplate="%s - React.js Boilerplate"
      defaultTitle="React.js Boilerplate"
    >
      <meta name="description" content="A React.js Boilerplate application" />
    </Helmet>
    <Header />

    <Switch>
      <Route exact path="/" component={HomePage} />
      <Route path="/features" component={FeaturePage} />
      <Route path="/login" component={Login} />
      <Route path="sponsors" component={Sponsors} />
      <Route path="/register" component={Register} />
      <Route path="/about" component={About} />
      <Route path="" component={NotFoundPage} />
    </Switch>
    <Footer />
  </div>
);

export default App;
