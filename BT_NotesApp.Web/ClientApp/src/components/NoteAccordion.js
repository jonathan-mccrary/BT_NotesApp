import React, { useState } from 'react';
import {
    Accordion
} from 'reactstrap';

export class NoteAccordion extends Component {
    constructor(props) {
        super(props);

        
        this.state = {
            collapsed: true
        };

        const [open, setOpen] = useState('1');
        const toggle = (id) => {
            if (open === id) {
                setOpen();
            } else {
                setOpen(id);
            }
        };
    }


    render() {
        return (
            <div>
                <Accordion open={open} toggle={toggle}>
                   this.props.
                </Accordion>
            </div>
        );
    }
}