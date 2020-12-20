# Contributing
`chainladder-python` welcomes volunteers for all aspects of the project. Whether
you're new to actuarial reserving, new to python, or both, feedback, questions,
suggestions and, of course, contributions as all welcome.

### How do I contribute?
There are tons of ways to improve and shape the direction of this project.
1. Submitting bugs or enhancements to the [issue tracker](https://github.com/casact/chainladder-python/issues).
2. Volunteer to draft code changes for existing [issues](https://github.com/casact/chainladder-python/issues).
3. Ask questions through [gitter](https://gitter.im/chainladder-python/community).
4. Improve the [documents](https://chainladder-python.readthedocs.io/en/latest/) where they are unclear.
5. Make new [examples](https://chainladder-python.readthedocs.io/en/latest/auto_examples/index.html).


### Why contribute?
1. Contributing to an open-source project is an incredibly rewarding learning
 experience. Whether your interests are in learning python, implementing functionality you need, or interested in software development, or gaining a deeper appreciation for how actuarial methods work, you will learn a ton.
2. Actuarial literature has a history of being free and open source, but we're
 barely scratching the surface on reproducible research or a similar level of freedom with regard to tools.
3. It's fun.

If you are interested in contributing.  Here are a few helpful hints to make the journey enjoyable.

### API guidelines
`chainladder-python` by design is intended to mimic the API styles of `pandas` and `scikit-learn`.  This benefits the on-going development of the package as API design is not up for debate which should eliminate many inquiries on how to write new functionality. In general,

1. the API for any estimator/transformer must strive to follow the [scikit-learn estimator API](https://scikit-learn.org/stable/developers/develop.html).
2. Methods for the `Triangle` classes should generally follow the same name and signature as `pandas` if it exists, followed by `numpy`. Methods that are truly domain specific with no equivalency in `pandas` or `numpy` should follow [PEP8](https://www.python.org/dev/peps/pep-0008/#method-names-and-instance-variables) naming convention.
3. `Triangle` methods should never be self-mutating by default.  Mutation is allowable with an `inplace` argument similar to pandas.

Occasionally, there will be cases where domain-specific functionality does not fit neatly into the existing API and these should be discussed in [issue](https://github.com/casact/chainladder-python/issues).

### Pull Requests
1. Pull requests (PR) should be tied to an [issue](https://github.com/casact/chainladder-python/issues).  It's generally a good idea to keep issues and
pull requests small.  Like all projects, the larger the PR, the less likely
it will be merged.
2. All pull requests must pass existing unit tests.  On occassion, existing unit tests can be in violation of the API guidelines.  These unit tests should be refined to accomodate the API ethos set forth above.  
3. New functionality should include new unit tests with a reasonable level of code coverage.

### Environment
There are several developer tools that are worth having when contributing to
python.

#### Documents
To build the documents, you should have sphinx and a few other packages
`nbsphinx`, `matplotlib`, `numpydoc`, `sphinx_gallery`.  The complete list is in `docs/rtfd-requirements.txt`


#### Unit tests
Unit tests rely on `pytest`. Every module has a `tests` directory where the unit tests can be found.  All unit tests can be run from the root directory
of the project with `pytest chainladder`.

#### Functionality in R
 Several of the unit tests use `rpy2` to call into R's version of
`chainladder`.  In general, if the functionality exists in R, it is worth
liberally writing tests that directly compares the two softwares.  The R dependencies
are available in `r_requirements.txt`.
