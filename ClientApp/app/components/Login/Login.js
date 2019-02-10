/* eslint-disable jsx-a11y/label-has-for */
import React, { Component } from 'react';
import Auth from 'components/Authenticate';
import './style.scss';

class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      name: '',
      password: '',
      message: '',
    };
    this.auth = new Auth();
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  // Ath name=email þarf að vera sama í target value
  handleChange(e) {
    this.setState({
      [e.target.name]: e.target.value,
      [e.target.password]: e.target.value,
    });
  }

  async handleSubmit(e) {
    e.preventDefault();

    const json = await this.auth.login(this.state.name, this.state.password);

    console.log(`password is ${this.state.password }: name is ${this.state.name}`);

    try {
      if (json.error.message) {
        this.setState({
          message: json.error.message,
        });
      }
    } catch {
      this.setState({
        message: 'You have logged in',
      });
    }
  }

  render() {
    return (
      <div className="form-body">

        <form onSubmit={this.handleSubmit}>

          <div className="form-group">
            <label>
              Name:
              <input
                type="text"
                name="name"
                className="form-control"
                value={this.state.value}
                onChange={this.handleChange}
              />
            </label>
          </div>

          <div className="form-group">
            <label>
              Password:
              <input
                type="password"
                name="password"
                className="form-control"
                value={this.state.value}
                onChange={this.handleChange}
              />
            </label>
          </div>

          <input
            type="submit"
            value="Submit"
            className="btn btn-primary"
          />
        </form>

      </div>
    );
  }
}

export default Login;
