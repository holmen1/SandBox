.. only:: html

    .. note::
        :class: sphx-glr-download-link-note

        Click :ref:`here <sphx_glr_download_auto_examples_plot_triangle_from_pandas.py>`     to download the full example code
    .. rst-class:: sphx-glr-example-title

    .. _sphx_glr_auto_examples_plot_triangle_from_pandas.py:


=======================
Basic Triangle Creation
=======================

This example demonstrates the typical way you'd ingest data into a Triangle.
Data in tabular form in a pandas DataFrame is required.  At a minimum, columns
specifying origin and development, and a value must be present.  Note, you can
include more than one column as a list as well as any number of indices for
creating triangle subgroups.

In this example, we create a triangle object with triangles for each company
in the CAS Loss Reserve Database for Workers' Compensation.



.. image:: /auto_examples/images/sphx_glr_plot_triangle_from_pandas_001.png
    :alt: CAS Loss Reserve Database: Workers Compensation
    :class: sphx-glr-single-img


.. rst-class:: sphx-glr-script-out

 Out:

 .. code-block:: none

    Raw data:
       GRCODE               GRNAME  AccidentYear  DevelopmentYear  DevelopmentLag  IncurLoss_D  CumPaidLoss_D  BulkLoss_D  EarnedPremDIR_D  EarnedPremCeded_D  EarnedPremNet_D  Single  PostedReserve97_D
    0      86  Allstate Ins Co Grp          1988             1988               1       367404          70571      127737           400699               5957           394742       0             281872
    1      86  Allstate Ins Co Grp          1988             1989               2       362988         155905       60173           400699               5957           394742       0             281872
    2      86  Allstate Ins Co Grp          1988             1990               3       347288         220744       27763           400699               5957           394742       0             281872
    3      86  Allstate Ins Co Grp          1988             1991               4       330648         251595       15280           400699               5957           394742       0             281872
    4      86  Allstate Ins Co Grp          1988             1992               5       354690         274156       27689           400699               5957           394742       0             281872

    Triangle summary:
    Valuation: 1997-12
    Grain:     OYDY
    Shape:     (132, 3, 10, 10)
    Index:      ['GRNAME']
    Columns:    ['IncurLoss_D', 'CumPaidLoss_D', 'EarnedPremDIR_D']

    Aggregate Paid Triangle:
               12        24         36         48         60         72         84         96         108        120
    1988  285804.0  638532.0   865100.0   996363.0  1084351.0  1133188.0  1169749.0  1196917.0  1229203.0  1241715.0
    1989  307720.0  684140.0   916996.0  1065674.0  1154072.0  1210479.0  1249886.0  1291512.0  1308706.0        NaN
    1990  320124.0  757479.0  1017144.0  1169014.0  1258975.0  1315368.0  1368374.0  1394675.0        NaN        NaN
    1991  347417.0  793749.0  1053414.0  1209556.0  1307164.0  1381645.0  1414747.0        NaN        NaN        NaN
    1992  342982.0  781402.0  1014982.0  1172915.0  1281864.0  1328801.0        NaN        NaN        NaN        NaN
    1993  342385.0  743433.0   959147.0  1113314.0  1187581.0        NaN        NaN        NaN        NaN        NaN
    1994  351060.0  750392.0   993751.0  1114842.0        NaN        NaN        NaN        NaN        NaN        NaN
    1995  343841.0  768575.0   962081.0        NaN        NaN        NaN        NaN        NaN        NaN        NaN
    1996  381484.0  736040.0        NaN        NaN        NaN        NaN        NaN        NaN        NaN        NaN
    1997  340132.0       NaN        NaN        NaN        NaN        NaN        NaN        NaN        NaN        NaN

    [Text(0, 0.5, 'Cumulative Paid Loss'), Text(0.5, 0, 'Development Period')]





|


.. code-block:: default


    import chainladder as cl
    import pandas as pd

    # Read in the data
    lobs = 'wkcomp'
    data = pd.read_csv(r'https://www.casact.org/research/reserve_data/wkcomp_pos.csv')
    data = data[data['DevelopmentYear']<=1997]

    # Create a triangle
    triangle = cl.Triangle(
        data, origin='AccidentYear', development='DevelopmentYear',
        index=['GRNAME'], columns=['IncurLoss_D','CumPaidLoss_D','EarnedPremDIR_D'])

    # Output
    print('Raw data:')
    print(data.head())
    print()
    print('Triangle summary:')
    print(triangle)
    print()
    print('Aggregate Paid Triangle:')
    print(triangle['CumPaidLoss_D'].sum())

    # Plot data
    triangle['CumPaidLoss_D'].sum().T.plot(
        marker='.', grid=True,
        title='CAS Loss Reserve Database: Workers Compensation').set(
        xlabel='Development Period', ylabel='Cumulative Paid Loss');


.. rst-class:: sphx-glr-timing

   **Total running time of the script:** ( 0 minutes  1.782 seconds)


.. _sphx_glr_download_auto_examples_plot_triangle_from_pandas.py:


.. only :: html

 .. container:: sphx-glr-footer
    :class: sphx-glr-footer-example



  .. container:: sphx-glr-download sphx-glr-download-python

     :download:`Download Python source code: plot_triangle_from_pandas.py <plot_triangle_from_pandas.py>`



  .. container:: sphx-glr-download sphx-glr-download-jupyter

     :download:`Download Jupyter notebook: plot_triangle_from_pandas.ipynb <plot_triangle_from_pandas.ipynb>`


.. only:: html

 .. rst-class:: sphx-glr-signature

    `Gallery generated by Sphinx-Gallery <https://sphinx-gallery.github.io>`_
