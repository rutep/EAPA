
import { Component } from 'react';

class Authenticate extends Component {
  constructor(props) {
    super(props);
    this.state = {
      name: '',
      password: '',
    };

    this.login = this.login.bind(this);
  }

  async login(name, password) {
    this.response = await fetch('http://localhost:8080/api/Users/login', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        username: name,
        password,
      })
    });

    const json = await this.response.json();

    sessionStorage.setItem('token', json.id);

    return json;
  }
}
export default Authenticate;
