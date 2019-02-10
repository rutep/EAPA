/*
 * Sponsorspage
 *
 * List all the sponsors
 * Eins og er þá er þetta ekki að tengjast, villa kemur upp. Þarf að skoða nánar eða byrja upp á nýtt.
 */
import React, { Component } from 'react';
import { Helmet } from 'react-helmet';
import './style.scss';

export default class SponsorsPage extends Component {
  // eslint-disable-line react/prefer-stateless-function

  // Since state and props are static,
  // there's no need to re-render this component
  shouldComponentUpdate() {
    return false;
  }

  render() {
    return (
      <div className="sponsors-page">
        <Helmet>
          <title>Sponsors Page</title>
          <meta
            name="description"
            content="Feature page of React.js Boilerplate application"
          />
        </Helmet>
        <h1>Features</h1>
        <ul>
          <li>
            <p className="title">Next generation JavaScript</p>
            <p>
              Hér koma listar af sponsorum
            </p>
          </li>
          <li>
            <p className="title">Instant feedback</p>
            <p>
              Hérna mega hlutir koma
            </p>
          </li>
          <li>
            <p className="title">Industry-standard routing</p>
            <p>
              {
                'Allt að koma í about woo'
              }
            </p>
          </li>
          <li>
            <p className="title">The Best Test Setup</p>
            <p>
              Automatically guarantee code quality and non-breaking changes.
              (Seen a react app with 99% test coverage before?)
            </p>
          </li>
        </ul>
        <i>and much more...</i>
      </div>
    );
  }
}
