import React, { Component } from 'react';

export class CreateNewHouse extends Component {
    static displayName = CreateNewHouse.name;

  //constructor(props) {
  //  super(props);

  //}


  render() {
    return (
        <div>
            <form>
                <label>
                    Name:
                    <input type="text" name="name" />
                </label>
                <input type="submit" value="Submit" />
            </form>
        </div>
    );
  }
}
