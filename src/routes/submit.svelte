<h1>Register your address</h1>

<div class="row justify-content-md-center">
    <article>
        <form method="POST" action="/api/AddAddress">
            <div class="mb-3">
                <label for="nameInput1" class="form-label">Name</label>
                <input
                    type="text"
                    name="preferredName"
                    class="form-control"
                    id="nameInput1"
                />
            </div>
            <div class="mb-3">
                <label for="addressInput1" class="form-label">Address</label>
                <input
                    type="text"
                    name="address"
                    class="form-control"
                    id="addressInput1"
                />
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
        </form>
    </article>
</div>
