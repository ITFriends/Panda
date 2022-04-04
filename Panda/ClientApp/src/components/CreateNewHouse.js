import React, { Component } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

export class CreateNewHouse extends Component {
    static displayName = CreateNewHouse.name;

    //constructor(props) {
    //  super(props);

    //}


    render() {
        return (
            <Form>
                <Form.Group className="mb-3">
                    <Form.Label>Number</Form.Label>
                    <Form.Control type="number" placeholder="Number" />
                    <Form.Text className="text-muted">
                        This is the number of cabin
                    </Form.Text>
                </Form.Group>

                <Form.Group className="mb-3">
                    <Form.Label>Price (in UAH)</Form.Label>
                    <Form.Control type="number" placeholder="Enter price" />
                    <Form.Text className="text-muted">
                        This is the price for a daily rental of cabin
                    </Form.Text>
                </Form.Group>

                <Form.Label>Family</Form.Label>
                <Form.Select aria-label="Select Family">
                    <option>Not selected</option>
                    <option value="0">Dog</option>
                    <option value="1">Cat</option>
                    <option value="2">Hamster</option>
                    <option value="3">Parrot</option>
                    <option value="4">Lizard</option>
                    <option value="5">Spider</option>
                </Form.Select>

                <Form.Label className="mt-5">Size (in meters)</Form.Label>
                <Form.Group className="mb-1">
                    <Form.Label>Length</Form.Label>
                    <Form.Control type="number" placeholder="Enter length" />
                </Form.Group>
                <Form.Group className="mb-1">
                    <Form.Label>Width</Form.Label>
                    <Form.Control type="number" placeholder="Enter width" />
                </Form.Group>
                <Form.Group className="mb-1">
                    <Form.Label>Height</Form.Label>
                    <Form.Control type="number" placeholder="Enter height" />
                </Form.Group>


                <Form.Label className="mt-5">Select status</Form.Label>
                <Form.Select aria-label="Select status">
                    <option>Not selected</option>
                    <option value="0">Free</option>
                    <option value="1">Occupied</option>
                </Form.Select>

                <Form.Group controlId="formFile" className="mt-5">
                    <Form.Label>Load picture of a new cabin</Form.Label>
                    <Form.Control type="file" />
                </Form.Group>

                <Button variant="primary" type="submit" className="mt-5">
                    Submit
                </Button>
            </Form>
        );
    }
}
