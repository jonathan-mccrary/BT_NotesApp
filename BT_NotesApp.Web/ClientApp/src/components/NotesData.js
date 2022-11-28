import React,
{
    Component
} from 'react';

import { ButtonGroup, Button } from 'reactstrap';

export class NotesData extends Component {
    static displayName = NotesData.name;

    constructor(props) {
        super(props);
        this.state = { notes: [], loading: true };
    }

    componentDidMount() {
        this.populateNotesData();
    }

    static renderNotesTable(notes) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th></th>
                        <th>Id</th>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Contents</th>
                        <th>Created Date</th>
                        <th>Updated Date</th>
                    </tr>
                </thead>
                <tbody>
                    {notes.map(note =>
                        <tr key={note.noteId}>
                            <td><input type="checkbox"/></td>
                            <td>{note.noteId}</td>
                            <td>{note.title}</td>
                            <td>{note.description}</td>
                            <td>{note.contents}</td>
                            <td>{note.createdDate}</td>
                            <td>{note.lastUpdatedDate}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : NotesData.renderNotesTable(this.state.notes);

        return (
            <div>
                <h1 id="tableLabel">Notes</h1>
                <ButtonGroup>
                    <Button>
                        Add
                    </Button>
                    <Button>
                        View
                    </Button>
                    <Button>
                        Edit
                    </Button>
                    <Button>
                        Delete
                    </Button>
                </ButtonGroup>
                {contents}
            </div>
        );
    }

    async populateNotesData() {
        const response = await fetch('notes');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }
}