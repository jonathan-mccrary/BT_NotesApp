import React, { useState } from 'react';
import {
    AccordionBody,
    AccordionHeader,
    AccordionItem,
} from 'reactstrap';

export class NoteItem extends Component {

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <AccordionItem>
                <AccordionHeader targetId="{props.id}">
                    <strong>{props.note.title}</strong>
                    <span>{props.note.description}</span>
                </AccordionHeader>
                <AccordionBody accordionId="{props.id}">
                    <div>{props.note.contents}</div>
                    <div>Created on {props.note.createdDate}</div>
                    <div>Updated on {props.note.updatedDate}</div>
                  </AccordionBody>
            </AccordionItem>
        );
    }
}
