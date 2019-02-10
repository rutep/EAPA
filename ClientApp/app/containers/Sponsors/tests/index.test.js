import React from 'react';
import { shallow } from 'enzyme';

import Sponsors from '../Sponsors';

describe('<Sponsors />', () => {
  it('should render its heading', () => {
    const renderedComponent = shallow(<Sponsors />);
    expect(renderedComponent.contains(<h1>About</h1>)).toBe(true);
  });

  it('should never re-render the component', () => {
    const renderedComponent = shallow(<Sponsors />);
    const inst = renderedComponent.instance();
    expect(inst.shouldComponentUpdate()).toBe(false);
  });
});
