.. only:: html

    .. note::
        :class: sphx-glr-download-link-note

        Click :ref:`here <sphx_glr_download_auto_examples_plot_exhibits.py>`     to download the full example code
    .. rst-class:: sphx-glr-example-title

    .. _sphx_glr_auto_examples_plot_exhibits.py:


==================================
Sample Excel Exhibit functionality
==================================

This example demonstrates some of the flexibility of the Excel outputs. It
creates an Excel file called 'clrd.xlsx' that includes various statistics on
industry development patterns for each line of business in the CAS loss reserve
database.

Output can be viewed online in `Google Sheets <https://docs.google.com/spreadsheets/d/1fwHK1Sys6aHDhEhFO6stVJtmZVKEcXXBsmJLSLIBLJY/edit#gid=1190415861>`_.

See :ref:`Exhibits<exhibits>` for more detail.

.. _exhibit_example:








.. code-block:: default

    import chainladder as cl
    import pandas as pd

    clrd = cl.load_sample('clrd').groupby('LOB').sum()['CumPaidLoss']

    # Line of Business Dictionary for looping
    lobs = dict(comauto='Commercial Auto',
                medmal='Medical Malpractice',
                othliab='Other Liability',
                ppauto='Private Passenger Auto',
                prodliab='Product Liability',
                wkcomp='Workers\' Compensation')


    sheets = []

    for lob_abb, lob in lobs.items():
        # Sample LDFs into a pandas dataframe
        ldfs = pd.concat((
            cl.Development(n_periods=2).fit(clrd.loc[lob_abb]).ldf_.to_frame(),
            cl.Development(n_periods=3).fit(clrd.loc[lob_abb]).ldf_.to_frame(),
            cl.Development(n_periods=7).fit(clrd.loc[lob_abb]).ldf_.to_frame(),
            cl.Development(n_periods=10).fit(clrd.loc[lob_abb]).ldf_.to_frame(),
            cl.Development().fit(clrd.loc[lob_abb]).ldf_.to_frame()))
        ldfs.index = ['2 Yr Wtd', '3 Yr Wtd', '7 Yr Wtd', '10 Yr Wtd', 'Selected']

        # Excel exhibit
        sheets.append(
            (lob,
             # Layout individual sheet vertically (i.e. Column)
             cl.Column(
                 cl.Title(['CAS Loss Reserve Database', lob, 'Cumulative Paid Loss',
                            'Evaluated as of December 31, 1997']),
                 cl.DataFrame(clrd.loc[lob_abb], index_label='Accident Year',
                               formats={'num_format': '#,#', 'align': 'center'}),
                 cl.CSpacer(),
                 cl.DataFrame(clrd.loc[lob_abb].link_ratio, index_label='Accident Year',
                               formats={'num_format': '0.000', 'align': 'center'}),
                 cl.CSpacer(),
                 cl.DataFrame(ldfs, index_label='Averages',
                               formats={'num_format': '0.000', 'align': 'center'})
             )))

    # Output to excel
    cl.Tabs(*sheets).to_excel('clrd.xlsx')


.. rst-class:: sphx-glr-timing

   **Total running time of the script:** ( 0 minutes  3.215 seconds)


.. _sphx_glr_download_auto_examples_plot_exhibits.py:


.. only :: html

 .. container:: sphx-glr-footer
    :class: sphx-glr-footer-example



  .. container:: sphx-glr-download sphx-glr-download-python

     :download:`Download Python source code: plot_exhibits.py <plot_exhibits.py>`



  .. container:: sphx-glr-download sphx-glr-download-jupyter

     :download:`Download Jupyter notebook: plot_exhibits.ipynb <plot_exhibits.ipynb>`


.. only:: html

 .. rst-class:: sphx-glr-signature

    `Gallery generated by Sphinx-Gallery <https://sphinx-gallery.github.io>`_
